using System;

namespace GoogleApi.Entities.Places.Search.Find.Request.Enums
{
    /// <summary>
    /// Field Types.
    /// </summary>
    [Flags]
    public enum FieldTypes
    {
        /// <summary>
        /// Formatted Address (billing: basic).
        /// </summary>
        Formatted_Address = 1 << 0,

        /// <summary>
        /// Geometry (billing: basic).
        /// </summary>
        Geometry = 1 << 1,

        /// <summary>
        /// Icon (billing: basic).
        /// </summary>
        Icon = 1 << 2,

        /// <summary>
        /// Id (billing: basic).
        /// </summary>
        Id = 1 << 3,

        /// <summary>
        /// Name (billing: basic).
        /// </summary>
        Name = 1 << 4,

        /// <summary>
        /// Permanently Closed (billing: basic).
        /// </summary>
        Permanently_Closed = 1 << 5,

        /// <summary>
        /// Photos (billing: basic).
        /// </summary>
        Photos = 1 << 6,

        /// <summary>
        /// Place_Id (billing: basic).
        /// </summary>
        Place_Id = 1 << 7,

        /// <summary>
        /// Plus_Code (billing: basic).
        /// </summary>
        Plus_Code = 1 << 8,

        /// <summary>
        /// Scope (billing: basic).
        /// </summary>
        Scope = 1 << 9,

        /// <summary>
        /// Types (billing: basic).
        /// </summary>
        Types = 1 << 10,

        /// <summary>
        /// Opening Hours (billing: contact).
        /// </summary>
        Opening_Hours = 1 << 11,

        /// <summary>
        /// Price Level (billing: atmosphere)
        /// </summary>
        Price_Level = 1 << 12,

        /// <summary>
        /// Rating (billing: atmosphere).
        /// </summary>
        Rating = 1 << 13
    }
}