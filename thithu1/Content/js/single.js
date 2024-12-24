
    //// Lắng nghe sự kiện click vào các tab
    //$(document).ready(function () {
    //    $('.tab').on('click', function () {
    //        var categoryId = $(this).data('id');  // Lấy ID của phân loại khi click
    //        loadProducts(categoryId);  // Gọi hàm để load sản phẩm
    //        // Thêm class active cho tab được chọn
    //        $('.tab').removeClass('active');
    //        $(this).addClass('active');
    //    });
    //});

    //// Hàm gọi AJAX để lấy sản phẩm theo phân loại
    //function loadProducts(categoryId) {
    //    $.ajax({
    //        url: '/Product/GetProductsByCategory', // Đường dẫn tới controller
    //        method: 'POST',
    //        contentType: 'application/json',
    //        data: JSON.stringify({ categoryId: categoryId }), // Gửi ID phân loại
    //        success: function (data) {
    //            // Cập nhật lại phần tử chứa sản phẩm với danh sách mới
    //            var productsHtml = '';
    //            data.forEach(function (product) {
    //                productsHtml += `
    //                    <div class="product-item col-lg-3 col-md-6 col-sm-6">
    //                        <div class="image-holder">
    //                            <img src="~/Content/images/${product.AnhDaiDien}" alt="${product.TenSanpham}" class="product-image">
    //                        </div>
    //                        <div class="product-detail">
    //                            <h3 class="product-title">
    //                                <a href="single-product.html">${product.TenSanpham}</a>
    //                            </h3>
    //                            <div class="item-price text-primary">$${product.Gia}</div>
    //                        </div>
    //                    </div>`;
    //            });
    //            $('.tab-content .row').html(productsHtml);  // Cập nhật lại danh sách sản phẩm
    //        },
    //        error: function () {
    //            alert('Error loading products.');
    //        }
    //    });
    //}

