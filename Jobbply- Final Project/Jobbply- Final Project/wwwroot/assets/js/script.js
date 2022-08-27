//find layout
function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
      
    }
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";
  }


    //succes alert
    document.getElementById("b3").onclick = function () {
        swal("Good job!", "You are already subscribed!", "success");
};
    //message 
    document.getElementById("b3").onclick = function () {
        swal("Good job!", "You clicked the button!", "success");
    };

  //transparent navbar
$(document).ready(function () {


    //search
    $(document).on("keyup", "#search-input", function () {
        let inputVal = $(this).val().trim();
        $("#searchList li").slice(1).remove();
        $.ajax({
            method: "get",
            url: "topCategory/SearchProduct?search=" + inputVal,
            success: function (res) {
                $("#searchList").append(res);
            }
        })

    })
    $(document).on('click', '#search', function () {
        $(this).next().toggle();
    })

      //partial view

    let skip = 4;
    
    $(document).on("click", "#loadmore", function () {
        let jobInfoCount = $("#jobInfoCount").val();
          $.ajax({
              method: "get",
              url: "topcategory/loadmore?skip="+skip,
              success: function (res) {
                  $("#listCategory").append(res);
                  skip += 4;
                  if (skip >= jobInfoCount) {
                      $("#loadmore").remove();
                  }
              }
          })
      })



      //scroll
    $(window).scroll(function() {

        var height = $('.navbar').height();
        var scrollTop = $(window).scrollTop();

        if (scrollTop >= height - 70) {
            $('.navbar').addClass('solid-nav');
        } else {
            $('.navbar').removeClass('solid-nav');
        }

    });
    
    $(window).scroll(function() {

      var height = $('.navbar').height();
      var scrollTop = $(window).scrollTop();

      if (scrollTop >= height + 70) {
          $('.navbar').addClass('solid-nav');
      } else {
          $('.navbar').removeClass('solid-nav');
      }

  });
});
  
//Counter
const counters = document.querySelectorAll(".counter");

counters.forEach((counter) => {
  counter.innerText = "0";

  const updateCounter = () => {
    const target = +counter.getAttribute("data-target");
    const c = +counter.innerText;

    const increment = target / 200;

    if (c < target) {
      counter.innerText = `${Math.ceil(c + increment)}`;
      setTimeout(updateCounter, 1);
    } else {
      counter.innerText = target;
    }
  };

  updateCounter();
});


// On Page Scroll Down
window.addEventListener('scroll',reveal);
function reveal(){
  var reveals=document.querySelectorAll('.reveal');

  for(var i=0; i<reveals.length; i++){
    var windowheight = window.innerHeight;
    var revealtop=reveals[i].getBoundingClientRect().top;
    var revealpoint =150;

    if(revealtop < windowheight - revealpoint){
      reveals[i].classList.add('active');
    }
    // else{
    //   reveals[i].classList.remove('active');
    // }
  }
}

// Left Scroll
window.addEventListener('scroll',leftreveal);
function leftreveal(){
  var leftreveals=document.querySelectorAll('.leftreveal');

  for(var i=0; i<leftreveals.length; i++){
    var windowheight = window.innerHeight;
    var revealtop=leftreveals[i].getBoundingClientRect().top;
    var revealpoint =150;

    if(revealtop < windowheight - revealpoint){
      leftreveals[i].classList.add('active');
    }
    // else{
    //   reveals[i].classList.remove('active');
    // }
  }
}


// swipper
var swiper = new Swiper(".card_slider", {
  // slidesPerView: 5,
  spaceBetween: 30,
  // loop:true,
  autoplay:{
      delay:2000,
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
  breakpoints: {
      320: {
        slidesPerView: 1,
      },
      // 480: {
      //     slidesPerView: 2,
      //   },
      768: {
        slidesPerView: 3,
      },
      1024: {
        slidesPerView: 5,
      },
    },
  });


  // Client-Slider
  var swiper = new Swiper(".card_client", {
    // slidesPerView: 3,
    spaceBetween: 30,
    loop:true,
    // autoplay:{
    //     delay:2000,
    // },
    pagination: {
      el: ".swiper-pagination",
      clickable: true,
    },
    breakpoints: {
        280: {
          slidesPerView: 1,
        },
        // 480: {
        //     slidesPerView: 2,
        //   },
        768: {
          slidesPerView: 3,
        },
        1024: {
          slidesPerView: 3,
        },
      },
    });