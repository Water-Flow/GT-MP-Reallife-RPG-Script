API.onUpdate.connect(function () {
    if (API.isCursorShown() && API.isDisabledControlJustPressed(24)) {

        const cursOp = API.getCursorPositionMaintainRatio();
        const s2W = API.screenToWorldMaintainRatio(cursOp);
        const rayCast = API.createRaycast(API.getGameplayCamPos(), s2W, -1, null);
        let localHandle = null;
        
        if (rayCast.didHitEntity) {
            localHandle = rayCast.hitEntity;

            resource.Events.registerHandler("onClick", localHandle);
        }
    }
});
