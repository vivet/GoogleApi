using System;
using System.Text;
using GoogleApi.Entities.Maps.StaticMaps.Request.Enums;

namespace GoogleApi.Entities.Maps.StaticMaps.Request
{
    /// <summary>
    /// Style rules are formatting options which are applied to the features and elements specified within each style declaration.
    /// </summary>
    public class StyleRule
    {
        /// <summary>
        /// hue(an RGB hex string of format #RRGGBB) indicates the basic color.
        /// Note: This option sets the hue while keeping the saturation and lightness specified in the default Google style(or in other style options you define on the map).
        /// The resulting color is relative to the style of the base map.
        /// If Google makes any changes to the base map style, the changes affect your map's features styled with hue.
        /// It's better to use the absolute color styler if you can.
        /// </summary>
        public virtual string Hue { get; set; }

        /// <summary>
        /// lightness(a floating point value between -100 and 100) indicates the percentage change in brightness of the element.
        /// Negative values increase darkness (where -100 specifies black) while positive values increase brightness(where +100 specifies white).
        /// Note: This option sets the lightness while keeping the saturation and hue specified in the default Google style(or in other style options you define on the map).
        /// The resulting color is relative to the style of the base map.
        /// If Google makes any changes to the base map style, the changes affect your map's features styled with lightness.
        /// It's better to use the absolute color styler if you can.
        /// </summary>
        public virtual float? Lightness { get; set; }

        /// <summary>
        /// saturation(a floating point value between -100 and 100) indicates the percentage change in intensity of the basic color to apply to the element.
        /// Note: This option sets the saturation while keeping the hue and lightness specified in the default Google style(or in other style options you define on the map).
        /// The resulting color is relative to the style of the base map.
        /// If Google makes any changes to the base map style, the changes affect your map's features styled with saturation.
        /// It's better to use the absolute color styler if you can.
        /// </summary>
        public virtual float? Saturation { get; set; }

        /// <summary>
        /// gamma(a floating point value between 0.01 and 10.0, where 1.0 applies no correction) indicates the amount of gamma correction to apply to the element.
        /// Gamma corrections modify the lightness of colors in a non-linear fashion, while not affecting white or black values.Gamma correction is typically used to modify the contrast of multiple elements.
        /// For example, you can modify the gamma to increase or decrease the contrast between the edges and interiors of elements.
        /// Note: This option adjusts the lightness relative to the default Google style, using a gamma curve.
        /// If Google makes any changes to the base map style, the changes affect your map's features styled with gamma.
        /// It's better to use the absolute color styler if you can.
        /// </summary>
        public virtual float? Gamma { get; set; }

        /// <summary>
        /// invert_lightness(if true) inverts the existing lightness.
        /// This is useful, for example, for quickly switching to a darker map with white text.
        /// Note: This option simply inverts the default Google style.
        /// If Google makes any changes to the base map style, the changes affect your map's features styled with invert_lightness.
        /// It's better to use the absolute color styler if you can.
        /// </summary>
        public virtual bool InvertLightness { get; set; } = false;

        /// <summary>
        /// visibility(on, off, or simplified) indicates whether and how the element appears on the map.
        /// A simplified visibility removes some style features from the affected features; roads, for example, are simplified into thinner lines without outlines,
        /// while parks lose their label text but retain the label icon.
        /// </summary>
        public virtual StyleVisibility Visibility { get; set; } = StyleVisibility.Off;

        /// <summary>
        /// color(an RGB hex string of format #RRGGBB) sets the color of the feature.
        /// weight(an integer value, greater than or equal to zero) sets the weight of the feature, in pixels.
        /// Setting the weight to a high value may result in clipping near tile borders.
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// weight(an integer value, greater than or equal to zero) sets the weight of the feature, in pixels.
        /// Setting the weight to a high value may result in clipping near tile borders.
        /// </summary>
        public virtual uint? Weight { get; set; }

        /// <summary>
        /// Returns a string representation of a <see cref="StyleRule"/>.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            var builder = new StringBuilder();

            if (this.Hue != null)
            {
                builder
                    .Append($"hue:{this.Hue}|");
            }

            if (this.Lightness != null)
            {
                if (this.Lightness is < -100 or > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Lightness), this.Lightness, $"The {nameof(this.Lightness)} must be between -100 and 100.");
                }

                builder
                    .Append($"lightness:{this.Lightness}|");
            }

            if (this.Saturation != null)
            {
                if (this.Saturation is < -100 or > 100)
                    throw new ArgumentOutOfRangeException(nameof(this.Saturation), this.Saturation, $"The {nameof(this.Saturation)} must be between -100 and 100.");

                builder
                    .Append($"saturation:{this.Saturation}|");
            }

            if (this.Gamma != null)
            {
                if (this.Gamma < 0.01 || this.Gamma > 10)
                    throw new ArgumentOutOfRangeException(nameof(this.Gamma), this.Gamma, $"The {nameof(this.Gamma)} must be between 0.01 and 10.00.");

                builder
                    .Append($"gamma:{this.Gamma}|");
            }

            if (this.InvertLightness)
            {
                builder
                    .Append("invert_lightness:true|");
            }

            if (this.Visibility != StyleVisibility.Off)
            {
                builder
                    .Append($"visibility:{this.Visibility.ToString().ToLower()}|");
            }

            if (this.Color != null)
            {
                builder
                    .Append($"color:{this.Color}|");
            }

            if (this.Weight != null)
            {
                builder
                    .Append($"weight:{this.Weight}|");
            }

            if (builder.Length == 0)
            {
                return null!;
            }

            return builder
                .ToString(0, builder.Length - 1);
        }
    }
}