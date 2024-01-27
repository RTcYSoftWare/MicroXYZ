namespace MicroXYZ.Database
{
    public class EmailTemplate : BaseEntity
    {        
        public string Label { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; }        
    }
}
