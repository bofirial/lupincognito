using System;
using System.Linq;
using Microsoft.AspNetCore.Components.Forms;

namespace Lupincognito.Web.Client.Validation
{
    public class CustomFieldCssClassProvider : FieldCssClassProvider
    {
        public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
        {
            if (editContext == null)
            {
                throw new ArgumentNullException(nameof(editContext));
            }

            if (!editContext.IsModified())
            {
                return string.Empty;
            }

            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "is-valid" : "is-invalid";
        }
    }
}
