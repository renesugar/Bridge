namespace System.Globalization
{
    /// <summary>
    /// Provides information about a specific culture (called a locale for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, the sort order of strings, and formatting for dates and numbers.
    /// </summary>
    [Bridge.Convention(Member = Bridge.ConventionMember.Field | Bridge.ConventionMember.Method, Notation = Bridge.Notation.CamelCase)]
    [Bridge.External]
    [Bridge.Reflectable]
    public class CultureInfo : ICloneable, IFormatProvider, Bridge.IBridgeClass
    {
        /// <summary>
        /// Initializes a new instance of the CultureInfo class based on the culture specified by name.
        /// </summary>
        /// <param name="name">A predefined CultureInfo name, Name of an existing CultureInfo, or Windows-only culture name. name is not case-sensitive.</param>
        public extern CultureInfo(string name);

        /// <summary>
        /// Retrieves a cached, read-only instance of a culture using the specified culture name.
        /// </summary>
        /// <param name="name">The name of a culture. name is not case-sensitive.</param>
        /// <returns>A read-only CultureInfo object.</returns>
        [Bridge.Name("getCultureInfo")]
        public static extern CultureInfo GetCultureInfo(string name);

        /// <summary>
        /// Creates a CultureInfo that represents the specific culture that is associated with the specified name.
        /// </summary>
        /// <param name="name">A predefined CultureInfo name or the name of an existing CultureInfo object. name is not case-sensitive.</param>
        /// <returns>A CultureInfo object</returns>
        [Bridge.Name("getCultureInfo")]
        public static extern CultureInfo CreateSpecificCulture(string name);

        public static extern CultureInfo[] GetCultures();

        /// <summary>
        /// Gets or sets the CultureInfo object that represents the culture used by the current thread.
        /// </summary>
        public static extern CultureInfo CurrentCulture
        {
            [Bridge.Template("{this}.getCurrentCulture()")]
            get;
            [Bridge.Template("{this}.setCurrentCulture({0})")]
            set;
        }

        /// <summary>
        /// Gets or sets a DateTimeFormatInfo that defines the culturally appropriate format of displaying dates and times.
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public extern DateTimeFormatInfo DateTimeFormat
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the CultureInfo object that is culture-independent (invariant).
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public static extern CultureInfo InvariantCulture
        {
            get;
        }

        /// <summary>
        /// Gets the culture name in the format languagecode2-country/regioncode2.
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public extern string Name
        {
            get;
        }

        /// <summary>
        /// Gets the culture name in the format languagefull [country/regionfull] in English.
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public extern string EnglishName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the culture name, consisting of the language, the country/region, and the optional script, that the culture is set to display.
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public extern string NativeName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a NumberFormatInfo that defines the culturally appropriate format of displaying numbers, currency, and percentage.
        /// </summary>
        [Bridge.Convention(Bridge.Notation.CamelCase)]
        public NumberFormatInfo NumberFormat
        {
            get;
            set;
        }

        public extern virtual Object GetFormat(Type formatType);

        /// <summary>
        /// Creates a copy of the current CultureInfo.
        /// </summary>
        /// <returns>A copy of the current CultureInfo.</returns>
        public extern object Clone();

        /// <summary>
        /// Gets the TextInfo that defines the writing system associated with the culture.
        /// </summary>
        public virtual TextInfo TextInfo { get; }
    }
}