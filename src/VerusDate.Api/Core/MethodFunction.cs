namespace VerusDate.Api.Core
{
    public struct FunctionMethod
    {
        /// <summary>
        /// Usado para recuperar uma informação
        /// </summary>
        public const string GET = "GET";

        /// <summary>
        /// Usado para criar um objeto no DB
        /// </summary>
        public const string POST = "POST";

        /// <summary>
        /// Usado para alterar um objeto no DB
        /// </summary>
        public const string PUT = "PUT";

        /// <summary>
        /// Usado para alterar parcialmente um objeto no DB
        /// </summary>
        public const string PATCH = "PATCH";

        /// <summary>
        /// Usado para deletar um objeto no DB
        /// </summary>
        public const string DELETE = "DELETE";
    }
}