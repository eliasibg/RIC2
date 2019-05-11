using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace RIC.Controllers
{
    public class Enumeradores
    {
        #region Codigos de estado HTTP
        /// <summary>
        /// 1xx: Respuestas informativas
        /// </summary>
        public enum InformationalResponses
        {
            Continue = 100
                , SwitchingProtocols = 101
                , Processing = 102
                , Checkpoint = 103
        }

        /// <summary>
        /// 2xx: Peticiones correctas
        /// </summary>
        public enum RequestsCorrect
        {
            OK = 200
                  , Created = 201
                  , Accepted = 202
                  , NonAuthoritativeInformation = 203
                  , NoContent = 204
                  , ResetContent = 205
                  , PartialContent = 206
                  , MultiStatus = 207
                  , AlreadyReported = 208
        }

        /// <summary>
        /// 3xx: Redirecciones
        /// </summary>
        public enum Redirects
        {
            MultipleChoices = 300
                , MovedPermanently = 301
                , Found = 302
                , SeeOther = 303
                , NotModified = 304
                , UseProxy = 305
                , SwitchProxy = 306
                , TemporaryRedirect = 307
                , PermanentRedirect = 308
        }

        /// <summary>
        /// 4xx Errores del cliente
        /// </summary>
        public enum CustomerErrors
        {
            BadRequest = 400
                , Unauthorized = 401
                , PaymentRequired = 402
                , Forbidden = 403
                , NotFound = 404
                , MethodNotAllowed = 405
                , NotAcceptable = 406
                , ProxyAuthenticationRequired = 407
                , RequestTimeout = 408
                , Conflict = 409
                , Gone = 410
                , LengthRequired = 411
                , PreconditionFailed = 412
                , RequestEntityTooLarge = 413
                , RequestURITooLong = 414
                , UnsupportedMediaType = 415
                , RequestedRangeNotSatisfiable = 416
                , ExpectationFailed = 417
                , Imateapot = 418
                , UnprocessableEntity = 422
                , Locked = 423
                , FailedDependency = 424
                , Unassigned = 425
                , UpgradeRequired = 426
                , PreconditionRequired = 428
                , TooManyRequests = 429
                , RequestHeaderFiledsTooLarge = 431
                , Other = 449
                , UnavailableforLegalReasons = 451
        }

        /// <summary>
        /// 5xx Errores de servidor
        /// </summary>
        public enum ServerErrors
        {
            InternalServerError = 500
                , NotImplemented = 501
                , BadGateway = 502
                , ServiceUnavailable = 503
                , GatewayTimeout = 504
                , HTTPVersionNotSupported = 505
                , VariantAlsoNegotiates = 506
                , InsufficientStorage = 507
                , LoopDetected = 508
                , BandwidthLimitExceeded = 509
                , NotExtended = 510
                , NetworkAuthenticationRequired = 511
                , Notupdated = 512
        }

        #endregion
    }
}
