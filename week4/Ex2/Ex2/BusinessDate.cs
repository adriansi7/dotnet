using Ex2;
using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
{
    private const string Iso8601DateFormat = "yyyy-MM-dd";
    private const string Iso8601DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";
    public int Day, Month, Year;

    public DateTime Date { get; set; }
    public BusinessDate(int year, int month, int day)
    {
        Date = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Unspecified);
        Day = day;
        Month = month;
        Year = year;
    }

    public BusinessDate(DateTime date)
    {
        Date = date;
        Day = date.Year;
        Month = date.Month;
        Year = date.Year;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        var escapedFormat = EscapeTimeFormatSpecifiers(format == null ? Iso8601DateFormat : format);
        return Date.ToString(escapedFormat, formatProvider);
    }
    private static string EscapeTimeFormatSpecifiers(string format)
    {
        return new BusinessDateFormatStringBuilder(format).EscapeFormatSpecifier("h")
            .EscapeFormatSpecifier("H")
            .EscapeFormatSpecifier("m")
            .EscapeFormatSpecifier("s")
            .EscapeFormatSpecifier("f")
            .EscapeFormatSpecifier("z")
            .EscapeFormatSpecifier("F")
            .EscapeFormatSpecifier("t")
            .EscapeFormatSpecifier("K")
            .ToString();
    }

    public XmlSchema GetSchema()
    {
        return null;
    }

    public void ReadXml(XmlReader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException("reader is invalid");
        }
        var text = reader.ReadElementContentAsString();
        this = new BusinessDate(DateTime.ParseExact(text, Iso8601DateFormat, CultureInfo.InvariantCulture));
    }

    public void WriteXml(XmlWriter writer)
    {
        writer.WriteElementString("Date", this.Date.ToString(Iso8601DateFormat));
    }

    public static BusinessDate ParseFromIso8601String(string newDate) 
    {
        //newDate = 2015-06- 10
        BusinessDate newBusinessDate = new BusinessDate(DateTime.Parse(newDate));        
        return newBusinessDate;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is BusinessDate))
            return false;

        BusinessDate other = (BusinessDate)obj;

        return other != null && Date == other.Date;
    }


    public int CompareTo(BusinessDate other)
    {
        if (this.GetType() != other.GetType())
        {
            throw new ArgumentException("The argument is not a BusinessDate");
        }

        if (other == null)
        {
            return 1;
        }

        return Date.CompareTo(other.Date);
    }
    public static int Compare(BusinessDate left, BusinessDate right)
    {
        if (object.ReferenceEquals(left, right))
        {
            return 0;
        }
        if (object.ReferenceEquals(left, null))
        {
            return -1;
        }
        return left.CompareTo(right);
    }

    public override int GetHashCode()
    {
        return Date.GetHashCode();
    }
    public bool Equals(BusinessDate other)
    {
        if (Object.ReferenceEquals(other, null))
        {
            return false;
        }

        if (this.GetType() != other.GetType())
        {
            return false;
        }

        if (Object.ReferenceEquals(this, other))
        {
            return true;
        }

        return Date == other.Date;
    }

    public static bool operator ==(BusinessDate a, BusinessDate b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(BusinessDate a, BusinessDate b)
    {
        return !a.Equals(b);
    }
    public static bool operator >(BusinessDate a, BusinessDate b)
    {
        return (Compare(a, b) > 0);
    }

    public static bool operator <(BusinessDate a, BusinessDate b)
    {
        return (Compare(a, b) < 0);
    }

    public static bool operator >=(BusinessDate a, BusinessDate b)
    {
        return (Compare(a, b) >= 0);
    }

    public static bool operator <=(BusinessDate a, BusinessDate b)
    {
        return (Compare(a, b) <= 0);
    }
}
