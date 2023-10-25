namespace SAIMS.Domain;
public class Customer{
    public int ID { get; set; }
    public string UserId { get; set; } = String.Empty;
    public string MyMembershipId { get; set; } = string.Empty;
    public bool IsActive{ get; set; }             
}