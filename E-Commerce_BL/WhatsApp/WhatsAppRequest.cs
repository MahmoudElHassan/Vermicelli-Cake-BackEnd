namespace E_Commerce_BL;

public class WhatsAppRequest
{
    public string messaging_product { get; set; } = "whatsapp";
    public string recipient_type { get; set; } = "individual";
    public string to { get; set; } = "201005152604";
    public string type { get; set; } = "template";
    public Template template { get; set; }
}
