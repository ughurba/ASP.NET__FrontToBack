using FrontToBackend.Models;
using System.Collections.Generic;

namespace FrontToBackend.ViewModels
{
    public class HomeVM
    {
        public List <Slider> sliders { get; set; }
        public SliderContent sliderContent { get; set; }
       public List <Category> categories { get; set; }
       public List <Product> products { get; set; }
        public List<Expert> experts { get; set; }
        public List<Blog> blogs { get; set; }
        public List<sliderBottom> sliderBottom { get; set; }
        public List<instagramSlider> instagramSliders { get; set; }
    }
}
