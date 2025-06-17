namespace Yoga.NET.Interop
{
    public partial struct Style
    {
        public byte _bitfield1;

        [NativeTypeName("facebook::yoga::Direction : 2")]
        private Direction direction_
        {
            readonly get
            {
                return (Direction)(_bitfield1 & 0x3u);
            }

            set
            {
                _bitfield1 = (byte)((_bitfield1 & ~0x3u) | ((byte)(value) & 0x3u));
            }
        }

        [NativeTypeName("facebook::yoga::FlexDirection : 2")]
        private FlexDirection flexDirection_
        {
            readonly get
            {
                return (FlexDirection)((_bitfield1 >> 2) & 0x3u);
            }

            set
            {
                _bitfield1 = (byte)((_bitfield1 & ~(0x3u << 2)) | (((byte)(value) & 0x3u) << 2));
            }
        }

        [NativeTypeName("facebook::yoga::Justify : 3")]
        private Justify justifyContent_
        {
            readonly get
            {
                return (Justify)((_bitfield1 >> 4) & 0x7u);
            }

            set
            {
                _bitfield1 = (byte)((_bitfield1 & ~(0x7u << 4)) | (((byte)(value) & 0x7u) << 4));
            }
        }

        public byte _bitfield2;

        [NativeTypeName("facebook::yoga::Align : 4")]
        private Align alignContent_
        {
            readonly get
            {
                return (Align)(_bitfield2 & 0xFu);
            }

            set
            {
                _bitfield2 = (byte)((_bitfield2 & ~0xFu) | ((byte)(value) & 0xFu));
            }
        }

        [NativeTypeName("facebook::yoga::Align : 4")]
        private Align alignItems_
        {
            readonly get
            {
                return (Align)((_bitfield2 >> 4) & 0xFu);
            }

            set
            {
                _bitfield2 = (byte)((_bitfield2 & ~(0xFu << 4)) | (((byte)(value) & 0xFu) << 4));
            }
        }

        public byte _bitfield3;

        [NativeTypeName("facebook::yoga::Align : 4")]
        private Align alignSelf_
        {
            readonly get
            {
                return (Align)(_bitfield3 & 0xFu);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~0xFu) | ((byte)(value) & 0xFu));
            }
        }

        [NativeTypeName("facebook::yoga::PositionType : 2")]
        private PositionType positionType_
        {
            readonly get
            {
                return (PositionType)((_bitfield3 >> 4) & 0x3u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x3u << 4)) | (((byte)(value) & 0x3u) << 4));
            }
        }

        [NativeTypeName("facebook::yoga::Wrap : 2")]
        private Wrap flexWrap_
        {
            readonly get
            {
                return (Wrap)((_bitfield3 >> 6) & 0x3u);
            }

            set
            {
                _bitfield3 = (byte)((_bitfield3 & ~(0x3u << 6)) | (((byte)(value) & 0x3u) << 6));
            }
        }

        public byte _bitfield4;

        [NativeTypeName("facebook::yoga::Overflow : 2")]
        private Overflow overflow_
        {
            readonly get
            {
                return (Overflow)(_bitfield4 & 0x3u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~0x3u) | ((byte)(value) & 0x3u));
            }
        }

        [NativeTypeName("facebook::yoga::Display : 2")]
        private Display display_
        {
            readonly get
            {
                return (Display)((_bitfield4 >> 2) & 0x3u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x3u << 2)) | (((byte)(value) & 0x3u) << 2));
            }
        }

        [NativeTypeName("facebook::yoga::BoxSizing : 1")]
        private BoxSizing boxSizing_
        {
            readonly get
            {
                return (BoxSizing)((_bitfield4 >> 4) & 0x1u);
            }

            set
            {
                _bitfield4 = (byte)((_bitfield4 & ~(0x1u << 4)) | (((byte)(value) & 0x1u) << 4));
            }
        }

        [NativeTypeName("facebook::yoga::StyleValueHandle")]
        private StyleValueHandle flex_;

        [NativeTypeName("facebook::yoga::StyleValueHandle")]
        private StyleValueHandle flexGrow_;

        [NativeTypeName("facebook::yoga::StyleValueHandle")]
        private StyleValueHandle flexShrink_;

        [NativeTypeName("facebook::yoga::StyleValueHandle")]
        private StyleValueHandle flexBasis_;

        [NativeTypeName("facebook::yoga::Style::Edges")]
        InlineArray9<StyleValueHandle> margin_;

        [NativeTypeName("facebook::yoga::Style::Edges")]
        InlineArray9<StyleValueHandle> position_;

        [NativeTypeName("facebook::yoga::Style::Edges")]
        InlineArray9<StyleValueHandle> padding_;

        [NativeTypeName("facebook::yoga::Style::Edges")]
        InlineArray9<StyleValueHandle> border_;

        [NativeTypeName("facebook::yoga::Style::Gutters")]
        InlineArray3<StyleValueHandle> gap_;

        [NativeTypeName("facebook::yoga::Style::Dimensions")]
        InlineArray2<StyleValueHandle> dimensions_;

        [NativeTypeName("facebook::yoga::Style::Dimensions")]
        InlineArray2<StyleValueHandle> minDimensions_;

        [NativeTypeName("facebook::yoga::Style::Dimensions")]
        InlineArray2<StyleValueHandle> maxDimensions_;

        [NativeTypeName("facebook::yoga::StyleValueHandle")]
        private StyleValueHandle aspectRatio_;

        [NativeTypeName("facebook::yoga::StyleValuePool")]
        private StyleValuePool pool_;

        [NativeTypeName("const float")]
        public const float DefaultFlexGrow = 0.0f;

        [NativeTypeName("const float")]
        public const float DefaultFlexShrink = 0.0f;

        [NativeTypeName("const float")]
        public const float WebDefaultFlexShrink = 1.0f;
    }
}
