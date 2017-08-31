
namespace ProtoBuf
{
    /// <summary>
    /// Sub-format to use when serializing/deserializing data
    /// </summary>
	public class DataFormat
    {
        /// <summary>
        /// Uses the default encoding for the data-type.
        /// </summary>
        public const byte Default = 0;

        /// <summary>
        /// When applied to signed integer-based data (including Decimal), this
        /// indicates that zigzag variant encoding will be used. This means that values
        /// with small magnitude (regardless of sign) take a small amount
        /// of space to encode.
        /// </summary>
        public const byte ZigZag  = 1;

        /// <summary>
        /// When applied to signed integer-based data (including Decimal), this
        /// indicates that two's-complement variant encoding will be used.
        /// This means that any -ve number will take 10 bytes (even for 32-bit),
        /// so should only be used for compatibility.
        /// </summary>
        public const byte TwosComplement = 2;

        /// <summary>
        /// When applied to signed integer-based data (including Decimal), this
        /// indicates that a fixed amount of space will be used.
        /// </summary>
        public const byte FixedSize = 3;

        /// <summary>
        /// When applied to a sub-message, indicates that the value should be treated
        /// as group-delimited.
        /// </summary>
        public const byte Group = 4;
    }
	/*
	public enum DataFormat
	{
		/// <summary>
		/// Uses the default encoding for the data-type.
		/// </summary>
		Default = 0,

		/// <summary>
		/// When applied to signed integer-based data (including Decimal), this
		/// indicates that zigzag variant encoding will be used. This means that values
		/// with small magnitude (regardless of sign) take a small amount
		/// of space to encode.
		/// </summary>
		ZigZag,

		/// <summary>
		/// When applied to signed integer-based data (including Decimal), this
		/// indicates that two's-complement variant encoding will be used.
		/// This means that any -ve number will take 10 bytes (even for 32-bit),
		/// so should only be used for compatibility.
		/// </summary>
		TwosComplement,

		/// <summary>
		/// When applied to signed integer-based data (including Decimal), this
		/// indicates that a fixed amount of space will be used.
		/// </summary>
		FixedSize,

		/// <summary>
		/// When applied to a sub-message, indicates that the value should be treated
		/// as group-delimited.
		/// </summary>
		Group
	}
	*/
}
