import { Component } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  luxurySlides = [
    { img: "https://i.imgur.com/Vwlvhe3.png" },
    { img: "https://i.imgur.com/Ua3nend.png" },
    { img: "https://i.imgur.com/zhnBL0R.png" },
    { img: "https://i.imgur.com/Vwlvhe3.png" },
    { img: "https://i.imgur.com/Ua3nend.png" },
    { img: "https://i.imgur.com/zhnBL0R.png" },
  ];

  suvSlides = [
    { img: "https://imgur.com/JMw9lhj.png" },
    { img: "https://imgur.com/Mtr3OWn.png" },
    { img: "https://imgur.com/dznT5Nm.png" },
    { img: "https://imgur.com/JMw9lhj.png" },
    { img: "https://imgur.com/Mtr3OWn.png" },
    { img: "https://imgur.com/dznT5Nm.png" },
  ];

  hatchbackSlides = [
    { img: "https://imgur.com/F2vAYLF.png" },
    { img: "https://imgur.com/NIBrW7j.png" },
    { img: "https://imgur.com/vqu9cnS.png" },
    { img: "https://imgur.com/F2vAYLF.png" },
    { img: "https://imgur.com/NIBrW7j.png" },
    { img: "https://imgur.com/vqu9cnS.png" },
  ];

  minivanSlides = [
    { img: "https://imgur.com/WhyeJlO.png" },
    { img: "https://imgur.com/n5djyYt.png" },
    { img: "https://imgur.com/V8fLLAq.png" },
    { img: "https://imgur.com/WhyeJlO.png" },
    { img: "https://imgur.com/n5djyYt.png" },
    { img: "https://imgur.com/V8fLLAq.png" },
  ];

  sportcarSlides = [
    { img: "https://imgur.com/eN2eifR.png" },
    { img: "https://imgur.com/C6eLrXg.png" },
    { img: "https://imgur.com/Zcb5MEq.png" },
    { img: "https://imgur.com/eN2eifR.png" },
    { img: "https://imgur.com/C6eLrXg.png" },
    { img: "https://imgur.com/Zcb5MEq.png" },
  ];

  slideConfig = {
    "slidesToShow": 3,
    "slidesToScroll": 1,
    "speed": 300,
    "centerMode": true,
    "centerPadding": "0px",
    "dots": true,
    "responsive": [
      {
        "breakpoint": 768,
        "settings": {
          "slidesToShow": 1,
          "slidesToScroll": 1,
        }
      },
    ]
  };
}
