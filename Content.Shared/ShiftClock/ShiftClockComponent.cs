namespace Content.Shared.ShiftClock;

[RegisterComponent]
public sealed partial class ShiftClockComponent : Component
{
    /// <summary>
    /// Text shown to contextualise the time shown when examined (e.g. "It reads {$time}")
    /// </summary>
    [DataField]
    public LocId ContextTextExamine = "clock-component-on-examine-context";
}