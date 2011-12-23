
using System.ComponentModel;
using System.Web.UI;
namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a video or movie.
    /// </summary>
    public class Video : ContainerControl
    {
        /// <summary>
        /// Creates a new instance of type <c>Video</c>
        /// </summary>
        public Video() : base(ContainerType.Video) { }


        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddBooleanAttribute(writer, "autoplay", AutoPlay);
            Helper.AddLowerCaseEnumIfNotZero(writer, "preload", PreLoad);
            Helper.AddBooleanAttribute(writer, "controls", DisplayControls);
            Helper.AddBooleanAttribute(writer, "loop", Loop);
            Helper.AddUrlAttributeIfNotEmpty(writer, "poster", Poster, this);
            Helper.AddBooleanAttribute(writer, "muted", IsMuted);
            Helper.AddStringAttributeIfNotEmpty(writer, "mediagroup", MediaGroup);
            Helper.AddUrlAttributeIfNotEmpty(writer, "src", Url, this);
        }

        /// <summary>
        /// Gets or sets a value that instructs the UA to automatically begin playback of the video as soon as it can do so without stopping
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to automatically begin playback of the video as soon as it can do so without stopping"), Themeable(false), Category("Behavior")]
        public bool AutoPlay { get; set; }

        /// <summary>
        /// Gets or sets a value that represents a hint to the UA about whether optimistic downloading of the video itself or its metadata is considered worthwhile
        /// </summary>
        [DefaultValue(PreLoadMode.NotSet), Description("Represents a hint to the UA about whether optimistic downloading of the video itself or its metadata is considered worthwhile"), Themeable(false), Category("Behavior")]
        public PreLoadMode PreLoad { get; set; }

        /// <summary>
        /// Gets or sets a value that instructs the UA to expose a user interface for controlling playback of the video
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to expose a user interface for controlling playback of the video"), Themeable(false), Category("Behavior")]
        public bool DisplayControls { get; set; }

        /// <summary>
        /// Gets or sets a value that instructs the UA to seek back to the start of the video upon reaching the end
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to seek back to the start of the video upon reaching the end"), Themeable(false), Category("Behavior")]
        public bool Loop { get; set; }

        /// <summary>
        /// Gets or sets the address of an image file for the UA to show while no video data is available
        /// </summary>
        [DefaultValue(""), Description("The address of an image file for the UA to show while no video data is available"), Themeable(false), Category("Behavior"), UrlProperty]
        public string Poster { get; set; }

        /// <summary>
        /// Gets or sets a value that represents the default state of the audio channel of the video, potentially overriding user preferences
        /// </summary>
        [DefaultValue(false), Description("Represents the default state of the audio channel of the video, potentially overriding user preferences"), Themeable(false), Category("Behavior")]
        public bool IsMuted { get; set; }

        /// <summary>
        /// Gets or sets a value that instructs the UA to link multiple videos and/or audio streams together
        /// </summary>
        [DefaultValue(""), Description("Instructs the UA to link multiple videos and/or audio streams together"), Themeable(false), Category("Behavior")]
        public string MediaGroup { get; set; }

        /// <summary>
        /// Gets or sets the URL for the video
        /// </summary>
        [DefaultValue(""), Description("The URL for the video"), Themeable(false), Category("Behavior"), UrlProperty]
        public string Url { get; set; }
    }
}
