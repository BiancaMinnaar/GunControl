using System.Reflection;

namespace GunControl.Root.ViewModel
{
    public class SVGBindingProperty
    {
        Assembly _svgAssembly;
        public Assembly SvgAssembly
        {
            get
            {
                if (_svgAssembly == null)
                {
                    _svgAssembly = typeof(App).GetTypeInfo().Assembly;
                }
                return _svgAssembly;
            }
        }

        public string SVGFullName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}

