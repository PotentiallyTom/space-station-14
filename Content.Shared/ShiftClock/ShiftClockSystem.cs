using Content.Shared.Examine;
using Robust.Shared.Timing;
using Content.Shared.Interaction.Events;
using Content.Shared.GameTicking;

namespace Content.Shared.ShiftClock;

public sealed partial class ShiftClockSystem : EntitySystem
{
    [Dependency] private readonly SharedGameTicker _gameTicker = default!;
    [Dependency] private readonly IGameTiming _gameTiming = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<ShiftClockComponent, ExaminedEvent>(OnExamined);
    }

    private void OnExamined(EntityUid uid, ShiftClockComponent comp, ExaminedEvent args)
    {
        if (!args.IsInDetailsRange)
            return;

        string currentTime = CurrentTimeAsString();
        string readText = Loc.GetString(comp.ContextTextExamine, ("time", currentTime));
        args.PushMarkup(readText);
        // var sealedText = comp.Sealed ? Loc.GetString(comp.ExamineTextSealed) : Loc.GetString(comp.ExamineTextUnsealed);

        // args.PushMarkup(sealedText);
    }

    private string CurrentTimeAsString()
    {
        TimeSpan stationTime = _gameTiming.CurTime.Subtract(_gameTicker.RoundStartTimeSpan);
        return stationTime.ToString("hh\\:mm\\:ss");
    }
}