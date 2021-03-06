﻿using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OnionPattern.Api.Configuration.Startup.Swagger
{
    /// <summary>
    /// Represents the Swagger/Swashbuckle operation filter used to document the implicit API version parameter.
    /// </summary>
    /// <remarks>This <see cref="IOperationFilter"/> is only required due to bugs in the <see cref="SwaggerGenerator"/>.
    /// Once they are fixed and published, this class can be removed.</remarks>
    public class SwaggerDefaultValues : IOperationFilter
    {
        /// <summary>
        /// Applies the filter to the specified operation using the given context.
        /// </summary>
        /// <param name="operation">The operation to apply the filter to.</param>
        /// <param name="context">The current operation filter context.</param>
        public void Apply(Operation operation, OperationFilterContext context)
        {

            foreach (var parameter in operation.Parameters.OfType<NonBodyParameter>())
            {
                var description = context.ApiDescription.ParameterDescriptions.FirstOrDefault(p => p.Name == parameter.Name);

                if (description == null) { continue; }
                if (string.IsNullOrWhiteSpace(parameter.Description))
                {
                    parameter.Description = description.ModelMetadata.Description;
                }

                if (description.RouteInfo == null) { continue; }
                if (parameter.Default == null)
                {
                    parameter.Default = description.RouteInfo.DefaultValue;
                }

                parameter.Required |= !description.RouteInfo.IsOptional;
            }
        }
    }
}

