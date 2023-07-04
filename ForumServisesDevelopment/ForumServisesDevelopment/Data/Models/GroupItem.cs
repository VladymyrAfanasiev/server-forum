namespace ForumServisesDevelopment.Data.Models
{
	public class GroupItem
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Text { get; set; }

		public ICollection<Comment> Comments { get; set; }
	}
}
