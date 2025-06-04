namespace Modelo
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }

        public static int InstanceCount;
        public int ObjectCount = 0;

        public bool Validate()
        {
            bool isValid = true;

            isValid = 
                this.Id > 0 &&
                !string.IsNullOrEmpty(Name) &&
                Address != null;

            return isValid;
        }

    }
}
