namespace MLaw.UserServices
{
    public record BaseDTO
    {
        public int Id { get; set; }

        public int ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
