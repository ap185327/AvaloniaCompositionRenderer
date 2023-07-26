using System;
using Avalonia;
using Avalonia.Rendering.Composition;

namespace AvaloniaApplication.Extensions;

public static class VisualExtensions
{
    public static void StartFadeInAnimation(this Visual control, TimeSpan duration)
    {
        if (duration == TimeSpan.Zero) return;

        var compositionVisual = ElementComposition.GetElementVisual(control);

        if (compositionVisual is null) return;

        var animation = compositionVisual.Compositor.CreateScalarKeyFrameAnimation();

        animation.InsertKeyFrame(0f, 0f);
        animation.InsertKeyFrame(0.5f, 0.5f);
        animation.InsertKeyFrame(1f, 1f);
        animation.Duration = duration;
        animation.Target = nameof(CompositionVisual.Opacity);

        compositionVisual.StartAnimation(nameof(CompositionVisual.Opacity), animation);
    }

    public static void StartFadeOutAnimation(this Visual control, TimeSpan duration)
    {
        if (duration == TimeSpan.Zero) return;

        var compositionVisual = ElementComposition.GetElementVisual(control);

        if (compositionVisual is null) return;

        var animation = compositionVisual.Compositor.CreateScalarKeyFrameAnimation();

        animation.InsertKeyFrame(0f, 1f);
        animation.InsertKeyFrame(0.5f, 0.5f);
        animation.InsertKeyFrame(1f, 0f);
        animation.Duration = duration;
        animation.Target = nameof(CompositionVisual.Opacity);

        compositionVisual.StartAnimation(nameof(CompositionVisual.Opacity), animation);
    }
}