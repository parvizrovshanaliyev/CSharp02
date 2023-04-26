namespace Blog.Shared.Localization
{
    public static class BaseLocalizationResourceKeys
    {
        public const string NoDataAvailableOnRequest = nameof(NoDataAvailableOnRequest);
        public const string RegisteredSuccessfully = nameof(RegisteredSuccessfully);
        public const string CreatedSuccessfully = nameof(CreatedSuccessfully);
        public const string ModifiedSuccessfully = nameof(ModifiedSuccessfully);
        public const string DeletedSuccessfully = nameof(DeletedSuccessfully);
        public const string NotFound = nameof(NotFound);

        // DataAnnotations
        public const string RequiredErrorMessage = nameof(RequiredErrorMessage);
        public const string MaxLengthErrorMessage = nameof(MaxLengthErrorMessage);
        public const string MinLengthErrorMessage = nameof(MinLengthErrorMessage);
        public const string DataTypeEmailAddressErrorMessage = nameof(DataTypeEmailAddressErrorMessage);
        public const string DataTypePasswordErrorMessage = nameof(DataTypePasswordErrorMessage);
        public const string DataTypePhoneNumberErrorMessage = nameof(DataTypePhoneNumberErrorMessage);
    }
}