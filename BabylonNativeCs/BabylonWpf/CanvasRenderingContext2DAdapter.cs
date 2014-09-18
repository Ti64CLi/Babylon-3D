using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabylonWpf
{
    public class CanvasRenderingContext2DAdapter : Web.CanvasRenderingContext2D
    {
        public int miterLimit
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string font
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string globalCompositeOperation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string msFillRule
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string lineCap
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool msImageSmoothingEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int lineDashOffset
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string shadowColor
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string lineJoin
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int shadowOffsetX
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int lineWidth
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Web.HTMLCanvasElement canvas
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object strokeStyle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int globalAlpha
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int shadowOffsetY
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object fillStyle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int shadowBlur
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string textAlign
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string textBaseline
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void restore()
        {
            throw new NotImplementedException();
        }

        public void setTransform(int m11, int m12, int m21, int m22, int dx, int dy)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void arc(double x, double y, int radius, int startAngle, int endAngle, bool anticlockwise = false)
        {
            throw new NotImplementedException();
        }

        public Web.TextMetrics measureText(string text)
        {
            throw new NotImplementedException();
        }

        public bool isPointInPath(double x, double y, string fillRule = null)
        {
            throw new NotImplementedException();
        }

        public void quadraticCurveTo(int cpx, int cpy, double x, double y)
        {
            throw new NotImplementedException();
        }

        public void putImageData(Web.ImageData imagedata, int dx, int dy, int dirtyX = 0, int dirtyY = 0, int dirtyWidth = 0, int dirtyHeight = 0)
        {
            throw new NotImplementedException();
        }

        public void rotate(int angle)
        {
            throw new NotImplementedException();
        }

        public void fillText(string text, double x, double y, int maxWidth = 0)
        {
            throw new NotImplementedException();
        }

        public void translate(double x, double y)
        {
            throw new NotImplementedException();
        }

        public void scale(double x, double y)
        {
            throw new NotImplementedException();
        }

        public Web.CanvasGradient createRadialGradient(double x0, double y0, int r0, double x1, double y1, int r1)
        {
            throw new NotImplementedException();
        }

        public void lineTo(double x, double y)
        {
            throw new NotImplementedException();
        }

        public float[] getLineDash()
        {
            throw new NotImplementedException();
        }

        public void fill(string fillRule = null)
        {
            throw new NotImplementedException();
        }

        public Web.ImageData createImageData(object imageDataOrSw, int sh = 0)
        {
            throw new NotImplementedException();
        }

        public Web.CanvasPattern createPattern(Web.HTMLElement image, string repetition)
        {
            throw new NotImplementedException();
        }

        public void closePath()
        {
            throw new NotImplementedException();
        }

        public void rect(double x, double y, double w, int h)
        {
            throw new NotImplementedException();
        }

        public void clip(string fillRule = null)
        {
            throw new NotImplementedException();
        }

        public void clearRect(double x, double y, double w, int h)
        {
            throw new NotImplementedException();
        }

        public void moveTo(double x, double y)
        {
            throw new NotImplementedException();
        }

        public Web.ImageData getImageData(int sx, int sy, int sw, int sh)
        {
            throw new NotImplementedException();
        }

        public void fillRect(double x, double y, double w, int h)
        {
            throw new NotImplementedException();
        }

        public void bezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, double x, double y)
        {
            throw new NotImplementedException();
        }

        public void drawImage(Web.HTMLElement image, int offsetX, int offsetY, int width = 0, int height = 0, int canvasOffsetX = 0, int canvasOffsetY = 0, int canvasImageWidth = 0, int canvasImageHeight = 0)
        {
            throw new NotImplementedException();
        }

        public void transform(int m11, int m12, int m21, int m22, int dx, int dy)
        {
            throw new NotImplementedException();
        }

        public void stroke()
        {
            throw new NotImplementedException();
        }

        public void strokeRect(double x, double y, double w, int h)
        {
            throw new NotImplementedException();
        }

        public void setLineDash(float[] segments)
        {
            throw new NotImplementedException();
        }

        public void strokeText(string text, double x, double y, int maxWidth = 0)
        {
            throw new NotImplementedException();
        }

        public void beginPath()
        {
            throw new NotImplementedException();
        }

        public void arcTo(double x1, double y1, double x2, double y2, int radius)
        {
            throw new NotImplementedException();
        }

        public Web.CanvasGradient createLinearGradient(double x0, double y0, double x1, double y1)
        {
            throw new NotImplementedException();
        }
    }
}
