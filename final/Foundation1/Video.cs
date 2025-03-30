using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> Comments { get; } = new List<Comment>();

    public void AddComment(string name, string text)
    {
        Comments.Add(new Comment { Name = name, Text = text });
    }

    public int GetCommentCount() => Comments.Count;

    public void DisplayComments()
    {
        foreach (var comment in Comments)
        {
            System.Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
    }
}