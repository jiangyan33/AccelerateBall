namespace AccelerateBall.Model
{
    public class Dict
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string FormartPercentage { get; set; }

        public decimal Percentage { get; set; }

        public Dict()
        {
        }

        public Dict(string code, string name, string value, string percentage)
        {
            Code = code;
            Name = name;
            Value = value;
            FormartPercentage = percentage;
            Percentage = decimal.Parse(percentage);
        }
    }
}
