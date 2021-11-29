namespace Shopee.Enum
{
    public enum CodeDefinition
    {
        TestCallback = 0,
        ShopAuthorization = 1,
        ShopDeauthorization = 2,
        OrderStatus = 3,
        TrackingPush = 4,
        ShopeeUpdates = 5,
        BannedItem = 6,
        ItemPromotion = 7,
        ReservedStockChange = 8,
        PromotionUpdate = 9,
        WebChat = 10,
        VideoUpload = 11,
        AuthorizationExpiry = 12,
        BrandRegisterResul = 13
    }

    public enum OrderStatus
    {
        UNPAID = 1,
        READY_TO_SHIP = 2,
        PROCESSED = 3,
        RETRY_SHIP = 4,
        SHIPPED = 5,
        TO_CONFIRM_RECEIVE = 7,
        IN_CANCEL = 8,
        CANCELLED = 9,
        TO_RETURN = 10,
        COMPLETED = 11
    }
}