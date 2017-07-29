/* let lastDoor = null;
let lastDoorV = null;
var localH = null;

API.onUpdate.connect(function () {
    if (API.isCursorShown()) {

        var cursOp = API.getCursorPositionMaintainRatio();
        var s2w = API.screenToWorldMaintainRatio(cursOp);
        var rayCast = API.createRaycast(API.getGameplayCamPos(), s2w, -1, null);
        var localV = 0;
        if (rayCast.didHitEntity) {
            localH = rayCast.hitEntity;
            localV = localH.Value;
        }
        
        if (localV !== lastDoorV) {
            if (localH != null) {
                API.setEntityTransparency(localH, 50);
            }
            if (lastDoor != null) {
                API.setEntityTransparency(lastDoor, 255);
            }
            lastDoor = localH;
            lastDoorV = localV;
        }
    } else {
        if (localH != null) {
            API.setEntityTransparency(localH, 255);
        }
        if (lastDoor != null) {
             API.setEntityTransparency(lastDoor, 255);
        }
        localH = null;
        lastDoor = null;
    }
}); */