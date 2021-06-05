namespace PassengersMonitoring.Common
{
    /// <summary>
    /// Available DB field sizes.
    /// </summary>
    public static class PropertyLengthLimitation
    {
        /// <summary>
        /// 10 chars.
        /// </summary>
        public const int Tiny = 10;

        /// <summary>
        /// 20 chars.
        /// </summary>
        public const int Small = 20;

        /// <summary>
        /// 60 chars.
        /// </summary>
        public const int SmallToMedium = 60;

        /// <summary>
        /// 100 chars.
        /// </summary>
        public const int MediumSmall = 100;

        /// <summary>
        /// 200 chars.
        /// </summary>
        public const int Medium = 200;

        /// <summary>
        /// 500 chars.
        /// </summary>
        public const int MediumLarge = 500;

        /// <summary>
        /// 1000 chars.
        /// </summary>
        public const int Large = 1000;

        /// <summary>
        /// 5000 chars.
        /// </summary>
        public const int Giant = 5000;
    }
}
