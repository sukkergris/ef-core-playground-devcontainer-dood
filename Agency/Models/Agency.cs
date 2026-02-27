namespace Agency.Models;

public class Agency
{
  public int Id { get; set; }
  public int Name { get; set; }
  public List<Agent> Agents { get; set; }
}
