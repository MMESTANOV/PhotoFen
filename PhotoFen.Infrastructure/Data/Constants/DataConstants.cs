namespace PhotoFen.Infrastructure.Data.Constants
{
    public static class DataConstants
    {
        public const int CategoryNameMinLength = 4;
        public const int CategoryNameMaxLength = 30;

        public const int PhotoTittleMinLength = 4;
        public const int PhotoTittleMaxLength = 50;
        public const int PhotoDescriptionMinLength = 8;
        public const int PhotoDescriptionMaxLength = 80;
        public const int PhotoMaxValue = 2000000;
        public const int PhotoMinValue = 100000;

        public const int PhotographerNameMinLength = 5;
        public const int PhotographerNameMaxLength = 40;
        public const int PhotographerDescriptionMinLength = 10;
        public const int PhotographerDescriptionMaxLength = 100;

        public const int CommentContentMinLength = 4;
        public const int CommentContentMaxLength = 255;

        public const int PublicationTittleMinLength = 8;
        public const int PublicationTittleMaxLength = 50;
        public const int PublicationContentMinLength = 100;
        public const int PublicationContentMaxLength = 5000;

        public const string DataTimeFormat = "dd-MM-yyyy, HH:mm";
    }
}
