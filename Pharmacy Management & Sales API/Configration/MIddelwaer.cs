 
using Pharmacy_Management___Sales_API.Configration;
using System.Net;
using System.Text.Json;

namespace App.Middleware
{
    // هذا Middleware مسؤول عن التقاط أي Exception يحدث في التطبيق
    // بدل ما يظهر Error طويل للمستخدم، يرجع Response مرتب
    public class ExceptionMiddleware
    {

        // يمثل الـ Middleware أو الـ Component التالي في Pipeline
        // يعني بعد ما يخلص هذا الـ Middleware يكمل الطلب للـ Controller
        private readonly RequestDelegate _next;


        // يستخدم لتسجيل الأخطاء في الـ Log
        // يساعدك تعرف مكان الخطأ ووقته
        private readonly ILogger<ExceptionMiddleware> _logger;



        // Constructor يتم استدعاؤه عند تشغيل الـ Middleware
        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger)
        {
            // نخزن الـ Middleware التالي
            _next = next;

            // نخزن الـ Logger لاستخدامه عند حدوث خطأ
            _logger = logger;
        }




        // هذه الدالة يتم تنفيذها مع كل Request يدخل على الـ API
        public async Task Invoke(HttpContext context)
        {
            try
            {
                // يسمح للطلب أن يكمل طريقه
                // Controller -> Service -> Repository
                await _next(context);
            }

            catch (Exception ex)
            {
                // إذا حدث Exception بأي مكان في التطبيق
                // يمسك الخطأ هنا


                // تسجيل تفاصيل الخطأ في ملف الـ Logs
                _logger.LogError(
                    ex,
                    "Unhandled Exception: {Message}",
                    ex.Message
                );


                // إرسال Response مناسب للعميل
                await HandleException(context, ex);
            }
        }




        // هذه الدالة تحدد نوع الخطأ وترجع Status Code مناسب
        private async Task HandleException(
            HttpContext context,
            Exception ex)
        {

            // لأن الـ Response سيكون JSON
            context.Response.ContentType = "application/json";



            // Response موحد لكل الأخطاء
            var response = new Compabel<object>
            {
                 satas = null,
                  success = false
            };



            // تحديد نوع الخطأ
            switch (ex)
            {


                // يستخدم للأخطاء التي سببها المستخدم
                // مثال:
                // Email موجود مسبقاً
                // البيانات غير صحيحة
                // Validation من Service

                case InvalidDataException:


                    // 400 Bad Request
                    // معناها الطلب وصل لكن البيانات خطأ
                    context.Response.StatusCode =
                        StatusCodes.Status400BadRequest;


                    // نعرض رسالة الخطأ
                    response.satas = ex.Message;

                    break;




                // يستخدم عندما لا نجد البيانات المطلوبة

                // مثال:
                // البحث عن Doctor ID غير موجود

                case KeyNotFoundException:


                    // 404 Not Found
                    context.Response.StatusCode =
                        StatusCodes.Status404NotFound;


                    response.satas = ex.Message;

                    break;




                // أي خطأ غير معروف
                // مثال:
                // Database Error
                // Null Reference
                // Bug في الكود

                default:


                    // 500 Internal Server Error
                    context.Response.StatusCode =
                        StatusCodes.Status500InternalServerError;



                    // لا نظهر تفاصيل الخطأ للمستخدم
                    // لأسباب أمنية
                    response.satas =
                        "Internal Server Error";


                    break;

            }




            // تحويل الـ
            // Object
            // إلى JSON وإرساله
            // للـ Client
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response)
            );
        }
    }
}