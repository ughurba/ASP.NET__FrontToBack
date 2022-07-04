
$(document).ready(function () {
 
    // HEADER

    $(document).on('click', '#search', function () {
        $(this).next().toggle();
    })

    $(document).on('click', '#mobile-navbar-close', function () {
        $(this).parent().removeClass("active");

    })
    $(document).on('click', '#mobile-navbar-show', function () {
        $('.mobile-navbar').addClass("active");

    })

    $(document).on('click', '.mobile-navbar ul li a', function () {
        if ($(this).children('i').hasClass('fa-caret-right')) {
            $(this).children('i').removeClass('fa-caret-right').addClass('fa-sort-down')
        }
        else {
            $(this).children('i').removeClass('fa-sort-down').addClass('fa-caret-right')
        }
        $(this).parent().next().slideToggle();
    })

    // SLIDER

    $(document).ready(function(){
        $(".slider").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
      });

    // PRODUCT

    $(document).on('click', '.categories', function(e)
    {
        e.preventDefault();
        $(this).next().next().slideToggle();
    })

    $(document).on('click', '.category li a', function (e) {
        e.preventDefault();
        let category = $(this).attr('data-id');
        let products = $('.product-item');
        
        products.each(function () {
            if(category == $(this).attr('data-id'))
            {
                $(this).parent().fadeIn();
            }
            else
            {
                $(this).parent().hide();
            }
        })
        if(category == 'all')
        {
            products.parent().fadeIn();
        }
    })

    // ACCORDION 

    $(document).on('click', '.question', function()
    {   
       $(this).siblings('.question').children('i').removeClass('fa-minus').addClass('fa-plus');
       $(this).siblings('.answer').not($(this).next()).slideUp();
       $(this).children('i').toggleClass('fa-plus').toggleClass('fa-minus');
       $(this).next().slideToggle();
       $(this).siblings('.active').removeClass('active');
       $(this).toggleClass('active');
    })

    // TAB

    $(document).on('click', 'ul li', function()
    {   
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().next().children('p.active').removeClass('active');

        $(this).parent().next().children('p').each(function()
        {
            if(dataId == $(this).attr('data-id'))
            {
                $(this).addClass('active')
            }
        })
    })

    $(document).on('click', '.tab4 ul li', function()
    {   
        $(this).siblings('.active').removeClass('active');
        $(this).addClass('active');
        let dataId = $(this).attr('data-id');
        $(this).parent().parent().next().children().children('p.active').removeClass('active');

        $(this).parent().parent().next().children().children('p').each(function()
        {
            if(dataId == $(this).attr('data-id'))
            {
                $(this).addClass('active')
            }
        })
    })

    // search
    $(document).on("keyup", "#input-search", function () {
        let inputValue = $(this).val();
        $("#searchList li").slice(1).remove();
        $.ajax({
            url: "home/SearchProduct?search=" + inputValue,
            method: "get",
            success: function (res) {
                $("#searchList").append(res);
            }
        })
    })

    //load more
   


    let skip = 2;
    $(document).on('click', '#button', function () {
        let productCount = $("#productCount").val()
        let productList = $('#productList');
        $.ajax({
            url: "/ProductContoller/LoadMore?skip="+skip,
            method: "get",
            success: function (res) {
                productList.append(res);
                skip += 2
                console.log(productCount)
                if (skip >= productCount) {
                    
                    $('#button').remove();
                }
            }
        })

    })

 

    // INSTAGRAM

    $(document).ready(function(){
        $(".instagram").owlCarousel(
            {
                items: 4,
                loop: true,
                autoplay: true,
                responsive:{
                    0:{
                        items:1
                    },
                    576:{
                        items:2
                    },
                    768:{
                        items:3
                    },
                    992:{
                        items:4
                    }
                }
            }
        );
      });

      $(document).ready(function(){
        $(".say").owlCarousel(
            {
                items: 1,
                loop: true,
                autoplay: true
            }
        );
      });
    

})


const closeBtn = document.querySelectorAll(".closeTd");
const addBtns = document.querySelectorAll(".addItem");
const countProduct = document.querySelector(".rounded-circle");
const minusBtns = document.querySelectorAll(".minusBtn");
const productCounts = document.querySelectorAll(".productCount");
const plusBtns = document.querySelectorAll(".plusBtn");
const prices = document.querySelectorAll(".price")


const getRequest = async () => {

    try {
        const resp = await axios.get("/basket/sizebasket");
        const productLength = resp.data

        countProduct.textContent = productLength;
    }
    catch {
        console.log("error")
    }
}


const getRequestPlus = async (id) => {
    try {

        const resp = await axios.get("/basket/plus?id=" + id);
       
        prices.forEach(price => {
            
            let priceId = price.getAttribute("data-id")
           
            if (priceId == id) {
               
                price.textContent = resp.data.productPrice
                
            }
        })

        productCounts.forEach(item => {
            let itemId = item.getAttribute("data-id")
            if (itemId == id) {
                item.textContent = resp.data.productCount
                
            }
        })

    } catch {
        console.log("error")
    }
}

plusBtns.forEach(btn => {
    function handlePlusCount() {
        const plusId = btn.getAttribute("data-id")
        getRequestPlus(plusId)
    }


    btn.addEventListener("click",handlePlusCount)
})

const getRequestMinus = async (id) => {
    try {
        const resp = await axios.get("/basket/minus?id=" + id);
        prices.forEach(price => {
            console.log(resp)
            let priceId = price.getAttribute("data-id")

            if (priceId == id) {

                price.textContent = resp.data.productPrice

            }
        })
  
        productCounts.forEach(item => {
            let itemId = item.getAttribute("data-id")

            if (itemId == id) {
               
                item.textContent = resp.data.productCount
            }
        })

    }
    catch {
        console.log("error")
    }
}


minusBtns.forEach(minus => {
    function handleMinusCount() {
  
        const minusId = minus.getAttribute("data-id");
        if (this.nextElementSibling.textContent == 1) {
            getRequest();
            getRequestMinus(minusId)
            this.parentElement.parentElement.remove();
            
           
        } else {
            getRequestMinus(minusId)
           
        }
                   
    }

    minus.addEventListener("click", handleMinusCount);
})




getRequest();

const getRequestAddItem = async (id) => {
    sizeBasket("/basket/additem?id=",id);
};

addBtns.forEach(addBtn => {


    function handleAddItem() {
       
        const itemId = addBtn.getAttribute("data-id")

        getRequestAddItem(itemId);
    }
 
    addBtn.addEventListener("click", handleAddItem);
   

});





closeBtn.forEach(btn => {

    btn.addEventListener("click", removeHandle)
    const id = btn.getAttribute("data-id")
    function removeHandle() {
        getRequest();
        getReguestRemoveItem(id)
        this.parentElement.remove();

    }

})

async function getReguestRemoveItem(id) {
 
        sizeBasket("/basket/remove?id=" , id)

}

async function sizeBasket(url, id) {
    try {
        const resp = await axios.get(url + id);
        const productLength = resp.data

        countProduct.textContent = productLength;
    }
    catch {
        console.log("error")
    }
  
}