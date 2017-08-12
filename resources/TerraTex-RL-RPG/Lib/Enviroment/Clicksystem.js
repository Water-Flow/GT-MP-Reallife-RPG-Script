API.onUpdate.connect(function () {
    if (API.isCursorShown() && API.isDisabledControlJustPressed(24)) {

        const cursOp = API.getCursorPositionMaintainRatio();
        const s2W = API.screenToWorldMaintainRatio(cursOp);
        const rayCast = API.createRaycast(API.getGameplayCamPos(), s2W, -1, null);
        
        if (rayCast.didHitEntity) {
            const localHandle = rayCast.hitEntity;

            resource.Events.triggerEvent("onClick", localHandle);
        }
    }
});
