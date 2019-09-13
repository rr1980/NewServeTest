using Microsoft.AspNetCore.Builder;

namespace NewServeTest.Web
{
    public static class SecurityHeadersExtension
    {
        public static void UseSecurityHeaders(this IApplicationBuilder app)
        {
            var policyCollection = new HeaderPolicyCollection()
            .AddDefaultSecurityHeaders()
            .RemoveServerHeader()
            .AddReferrerPolicyStrictOrigin()
            .AddCustomHeader("Expect-CT", "enforce, max-age=0")
            .AddContentSecurityPolicy(builder =>
            {
                builder.AddFrameAncestors().Self();
                builder.AddDefaultSrc().None();
                builder.AddScriptSrc().Self().UnsafeInline().UnsafeEval();
                builder.AddStyleSrc().Self().UnsafeInline();
                builder.AddImgSrc().Self();
                builder.AddFormAction().Self();
                builder.AddConnectSrc().Self();
                builder.AddBaseUri().Self();
            })
            .AddFeaturePolicy(builder =>
            {
                builder.AddFullscreen().All();

                builder.AddAccelerometer().None();
                builder.AddAmbientLightSensor().None();
                builder.AddAutoplay().None();
                builder.AddCamera().None();
                builder.AddEncryptedMedia().None();
                builder.AddGeolocation().None();
                builder.AddGyroscope().None();
                builder.AddMagnetometer().None();
                builder.AddMicrophone().None();
                builder.AddMidi().None();
                builder.AddPayment().None();
                builder.AddPictureInPicture().None();
                builder.AddSpeaker().None();
                builder.AddSyncXHR().None();
                builder.AddUsb().None();
                builder.AddVR().None();
            });

            app.UseSecurityHeaders(policyCollection);
        }
    }
}
