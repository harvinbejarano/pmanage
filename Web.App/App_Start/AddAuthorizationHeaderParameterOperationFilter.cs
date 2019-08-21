using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http.Description;

namespace Web.App.App_Start
{
    public class AddAuthorizationHeaderParameterOperationFilter: IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null) operation.parameters = new List<Parameter>();

            if (operation.parameters != null)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization",
                    @in = "header",
                    description = "access token",
                    required = false,
                    type = "string",
                    @default = "Bearer "
                });
            }
           
        }
    }
}