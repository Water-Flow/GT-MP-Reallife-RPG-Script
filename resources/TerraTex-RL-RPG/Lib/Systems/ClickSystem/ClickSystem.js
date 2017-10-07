API.onUpdate.connect(function () {
    if (API.isCursorShown() && API.isDisabledControlJustPressed(24)) {

        const cursOp = API.getCursorPositionMaintainRatio();
        const s2W = API.screenToWorldMaintainRatio(cursOp);

        if (s2W) {
            const calVector = Vector3.Lerp(API.getGameplayCamPos(), s2W, 5);

            const rayCast = API.createRaycast(API.getGameplayCamPos(), calVector, -1, null);

            if (rayCast.didHitEntity && rayCast.hitCoords.DistanceTo(API.getGameplayCamPos()) <= 10) {
                const localHandle = rayCast.hitEntity;
                if (API.getEntityType(localHandle) === 255) {
                    API.triggerServerEvent("onClientClickWorld", JSON.stringify({
                        positionX: rayCast.hitCoords.X,
                        positionY: rayCast.hitCoords.Y,
                        positionZ: rayCast.hitCoords.Z,
                        hash: API.getEntityModel(localHandle)
                    }));
                } else {
                    API.triggerServerEvent("onClientClick", localHandle);
                }

                resource.Events.triggerEvent("onClick", localHandle);
            }
        }
    }
});
