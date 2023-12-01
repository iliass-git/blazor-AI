using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace BlazorAI.Services;
public class FacerecognitionService
{

    public async Task<string> ProcessImageAsync(string fileName)
    {

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "media");
        var imagePath = Path.Combine(path, fileName);
        var img = System.Drawing.Image.FromFile(imagePath);
        var modelPath = Path.Combine(Directory.GetCurrentDirectory(), "Service", "haarcascade_frontalface_default.xml");
        var faceCascade = new CascadeClassifier(modelPath);
        Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
        Rectangle[] facesDetected = faceCascade.DetectMultiScale(image); 
        foreach (Rectangle face in facesDetected){
            using (Graphics graphics = Graphics.FromImage(img))
            {
                using (Pen pen = new Pen(Color.Red, 5))
                {
                    graphics.DrawRectangle(pen, face);
                }
            }
        }
        img.Save($"{path}\\{fileName}-processed.jpg");
        return $"{fileName}-processed.jpg";
    }

}
