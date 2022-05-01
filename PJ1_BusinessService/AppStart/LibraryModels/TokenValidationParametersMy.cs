using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;

namespace PJ1_BusinessService.AppStart.LibraryModels;

/// <summary>
/// Содержит набор параметров, которые используются  <see cref="SecurityTokenHandler"/>
/// при проверке <see cref="SecurityToken"/>.
/// </summary>
public class TokenValidationParametersMy: TokenValidationParameters
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TokenValidationParameters"/>.
    /// </summary>
    /// <remarks>Содержит набор параметров, которые используются <see cref="SecurityTokenHandler"/>
    /// при проверке <see cref="SecurityToken"/></remarks> 
    public TokenValidationParametersMy()
    {
        RequireExpirationTime = true;
        RequireSignedTokens = true;
        RequireAudience = true;
        SaveSigninToken = false;
        ValidateActor = false;
        ValidateAudience = true;
        ValidateIssuer = true;
        ValidateIssuerSigningKey = false;
        ValidateLifetime = true;
        ValidateTokenReplay = false;
    }
    
    /// <summary>
    /// Получает или задает значение, указывающее, должны ли маркеры иметь значение "expiration".
    /// </summary>
    [DefaultValue(true)]
    public bool RequireExpirationTime { get; set; }
    
    /// <summary>
    /// Получает или задает значение, указывающее, можно ли
    /// считать  <see cref="SecurityToken"/> допустимым, если он не подписан.
    /// </summary>
    [DefaultValue(true)]
    public bool RequireSignedTokens { get; set; }
    
    /// <summary>
    /// Получает или задает значение, указывающее, должны ли token SAML
    /// иметь хотя бы один AudienceRestriction.
    /// </summary>
    [DefaultValue(true)]
    public bool RequireAudience { get; set; }
    
    /// <summary>
    /// Получает или задает логическое значение для управления сохранением
    /// исходного token после проверки token безопасности.
    /// </summary>
    /// <remarks>Среда выполнения обратится к этому значению и сохранит
    /// исходный token, который был проверен.</remarks>
    [DefaultValue(false)]
    public bool SaveSigninToken { get; set; }
    
    /// <summary>
    /// Получает или задает значение, указывающее, обнаружен ли маркер
    /// субъекта, должен ли он быть проверен.
    /// </summary>
    [DefaultValue(false)]
    public bool ValidateActor { get; set; }
    
    /// <summary>
    /// Получает или задает логическое значение для управления проверкой слушателя
    /// во время проверки token.
    /// </summary>
    /// <remarks>Проверка слушателя, смягчает переадресацию атак. Например,
    /// сайт, получивший токен, не смог переиграть его на другую сторону.
    /// Переадресованный токен будет содержать аудиторию исходного сайта.</remarks>
    [DefaultValue(true)]
    public bool ValidateAudience { get; set; }
    
    /// <summary>
    /// Получает или задает логическое значение для управления проверкой
    /// издателя во время проверки token.
    /// </summary>
    /// <remarks>
    /// Проверка издателя смягчает атаки переадресации, которые могут произойти,
    /// когда IdentityProvider представляет несколько клиентов
    /// и подписывает tokens одними и теми же ключами.
    /// Возможно, что токен, выпущенный для той же аудитории, может быть от другого владелеца.
    /// Например, приложение может принимать пользователей из contoso.onmicrosoft.com,
    /// но не fabrikam.onmicrosoft.com, оба допустимых клиента.
    /// Приложение, принимающее tokens от fabrikam, может переслать их
    /// приложению, принимающему tokens для contoso.
    /// </remarks>
    [DefaultValue(true)]
    public bool ValidateIssuer { get; set; }
    
    /// <summary>
    /// Получает или устанавливает логический, который контролирует, е
    /// сли называется проверка <see cref="SecurityKey"/>, который подписал SecurityToken.
    /// </summary>
    /// <remarks>
    /// Токены могут содержать public key, необходимый для проверки подписи.</remarks>
    [DefaultValue(false)]
    public bool ValidateIssuerSigningKey { get; set; }

    /// <summary>
    /// Получает или устанавливает логическое управление, если срок службы
    /// будет подтверждена во время проверки токена.
    /// </summary>                
    [DefaultValue(true)]
    public bool ValidateLifetime { get; set; }
    
    /// <summary>
    /// Получает или устанавливает логическое управление, если воспроизведение
    /// токена будет проверено во время проверки токена.
    /// </summary>                
    [DefaultValue(false)]
    public bool ValidateTokenReplay { get; set; }
    
}