using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Lupincognito.Web.Client.Validation;
public class MessageValidatorBase<TValue> : ComponentBase, IDisposable
{
    private FieldIdentifier _fieldIdentifier;

    private EventHandler<ValidationStateChangedEventArgs> StateChangedHandler => (sender, args) => StateHasChanged();

    [CascadingParameter]
    private EditContext EditContext { get; set; }

    [Parameter]
    public Expression<Func<TValue>> For { get; set; }

    [Parameter]
    public string Class { get; set; }

    protected IEnumerable<string> ValidationMessages =>
        EditContext.GetValidationMessages(_fieldIdentifier);

    protected override void OnInitialized()
    {
        _fieldIdentifier = FieldIdentifier.Create(For);
        EditContext.OnValidationStateChanged += StateChangedHandler;
    }

    [SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "Nothing will derive from this class")]
    public void Dispose() => EditContext.OnValidationStateChanged -= StateChangedHandler;
}
