using Emgu.CV.CvEnum;
using Emgu.CV;
using System.Drawing;

namespace Core_Proje.Areas.Helpers
{
    public class PoseDetector
    {
        public bool DetectBody(string imagePath)
        {
            Mat image = CvInvoke.Imread(imagePath, ImreadModes.Color);

            if (image == null || image.IsEmpty)
            {
                return false;
            }

            
            string[] haarCascades = new string[]
            {
                "haarcascade/HaarCascade_upperbody.xml",
                "haarcascade/haarcascade_frontalcatface_extended.xml",
                "haarcascade/haarcascade_fullbody.xml",
                "haarcascade/haarcascade_lowerbody.xml",
                "haarcascade/haarcascade_profileface.xml"
            };

            
            foreach (string cascadeFile in haarCascades)
            {
                using (CascadeClassifier classifier = new CascadeClassifier(cascadeFile))
                {
                    Rectangle[] detectedBodies = classifier.DetectMultiScale(image);
                    if (detectedBodies.Length > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
