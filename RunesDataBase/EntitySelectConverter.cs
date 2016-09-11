using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RunesDataBase
{
    public class EntitySelectConverter<T> : TypeConverter
    {
        public static Func<IDictionary<string, T>> StandardValues { get; set; }

        public static IDictionary<Type, IStringConverter> StringConverters  { get; set; } = new Dictionary<Type, IStringConverter>();
        public static void SetStringConverter(IStringConverter conv)
        {
            StringConverters[typeof (T)] = conv;
        }
        private static IStringConverter GetStringConverter()
        {
            IStringConverter converter;
            if (StringConverters.TryGetValue(typeof(T), out converter))
                return converter;
            return SimpleStringConverter.Instance;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) 
            => true;

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection((ICollection) StandardValues()?.Values.ToArray() ?? new List<T>());
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) 
            => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            var stringValue = value as string;
            if (stringValue == null)
                return base.ConvertFrom(context, culture, value);

            stringValue = GetStringConverter().Convert(stringValue);

            var obj = default(T);
            return (StandardValues()?.TryGetValue(stringValue, out obj) ?? false) 
                ? obj 
                : base.ConvertFrom(context, culture, value);
        }
    }
}