using UnityEngine;
using System.Collections;
using SLua;

namespace Slua.SluaCompents
{
    interface ISluaScriptsComponent
    {
        LuaTable getScripts();

        void setScripts(LuaTable table, string name);
    }

    public class SluaScriptsComponent
       : MonoBehaviour
       , ISluaScriptsComponent
    {
        protected LuaTable luaScripts;

        public LuaTable getScripts()
        {
            return luaScripts;
        }

        virtual public void setScripts(LuaTable table, string name)
        {
            this.name = name;

            if (table != null)
            {
                luaScripts = table;
                luaScripts["Userdata"] = this;
                luaAwake = (LuaFunction)table["Awake"];
                luaStart = (LuaFunction)table["Start"];
                luaReset = (LuaFunction)table["Reset"];
                luaOnEnable = (LuaFunction)table["OnEnable"];
                luaOnDisable = (LuaFunction)table["OnDisable"];
                luaOnDestroy = (LuaFunction)table["OnDestroy"];
            }
        }

        LuaFunction luaAwake;
        public void Awake()
        {
            if (luaAwake != null) luaAwake.call(luaScripts);
        }


        LuaFunction luaStart;
        public void Start()
        {

            if (luaStart != null) luaStart.call(luaScripts);
        }

        LuaFunction luaReset;
        public void Reset()
        {
            if (luaReset != null) luaReset.call(luaScripts);
        }

        LuaFunction luaOnEnable;
        public void OnEnable()
        {
            if (luaOnEnable != null) luaOnEnable.call(luaScripts);
        }

        LuaFunction luaOnDisable;
        public void OnDisable()
        {
            if (luaOnDisable != null) luaOnDisable.call(luaScripts);
        }

        LuaFunction luaOnDestroy;
        public void OnDestroy()
        {
            if (luaOnDestroy != null)
            {
                luaOnDestroy.call(luaScripts);
                luaScripts.Dispose();
                luaScripts = null;
            }
        }

    }

    public class SluaScheduleBehaviour
        : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table, name);
                luaUpdate = (LuaFunction)table["Update"];
            }
        }

        LuaFunction luaUpdate;
        public void Update()
        {
            if (luaUpdate != null) luaUpdate.call(luaScripts);
        }
    }



    public class SluaScheduleFixedBehaviour
       : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table, name);
                luaLateUpdate = (LuaFunction)table["LateUpdate"];
                luaFixedUpdate = (LuaFunction)table["FixedUpdate"];
            }
        }

        LuaFunction luaLateUpdate;
        public void LateUpdate()
        {
            if (luaLateUpdate != null) luaLateUpdate.call(luaScripts);
        }

        LuaFunction luaFixedUpdate;
        public void FixedUpdate()
        {
            if (luaFixedUpdate != null) luaFixedUpdate.call(luaScripts);
        }
    }


    public class SluaBecameBehaviour
        : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table, name);
                luaOnBecameVisible = (LuaFunction)table["OnBecameVisible"];
                luaOnBecameInvisible = (LuaFunction)table["OnBecameInvisible"];
            }
        }

        LuaFunction luaOnBecameVisible;
        public void OnBecameVisible()
        {
            if (luaOnBecameVisible != null) luaOnBecameVisible.call(luaScripts);
        }

        LuaFunction luaOnBecameInvisible;
        public void OnBecameInvisible()
        {
            if (luaOnBecameInvisible != null) luaOnBecameInvisible.call(luaScripts);
        }

    }


    public class SluaMouseBehaviour
       : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table, name);
                luaOnMouseEnter = (LuaFunction)table["OnMouseEnter"];
                luaOnMouseOver = (LuaFunction)table["OnMouseOver"];
                luaOnMouseExit = (LuaFunction)table["OnMouseExit"];
                luaOnMouseDown = (LuaFunction)table["OnMouseDown"];
                luaOnMouseUp = (LuaFunction)table["OnMouseUp"];
                luaOnMouseUpAsButton = (LuaFunction)table["OnMouseUpAsButton"];
                luaOnMouseDrag = (LuaFunction)table["OnMouseDrag"];
            }
        }

        LuaFunction luaOnMouseEnter;
        public void OnMouseEnter()
        {
            if (luaOnMouseEnter != null) luaOnMouseEnter.call(luaScripts);
        }

        LuaFunction luaOnMouseOver;
        public void OnMouseOver()
        {
            if (luaOnMouseOver != null) luaOnMouseOver.call(luaScripts);
        }

        LuaFunction luaOnMouseExit;
        public void OnMouseExit()
        {
            if (luaOnMouseExit != null) luaOnMouseExit.call(luaScripts);
        }

        LuaFunction luaOnMouseDown;
        public void OnMouseDown()
        {
            if (luaOnMouseDown != null) luaOnMouseDown.call(luaScripts);
        }

        LuaFunction luaOnMouseUp;
        public void OnMouseUp()
        {
            if (luaOnMouseUp != null) luaOnMouseUp.call(luaScripts);
        }

        LuaFunction luaOnMouseUpAsButton;
        public void OnMouseUpAsButton()
        {
            if (luaOnMouseUpAsButton != null) luaOnMouseUpAsButton.call(luaScripts);
        }

        LuaFunction luaOnMouseDrag;
        public void OnMouseDrag()
        {
            if (luaOnMouseDrag != null) luaOnMouseDrag.call(luaScripts);
        }
    }

    public class SluaRenderBehaviour
      : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table,name);
                luaOnPreCull = (LuaFunction)table["OnPreCull"];
                luaOnPreRender = (LuaFunction)table["OnPreRender"];
                luaOnPostRender = (LuaFunction)table["OnPostRender"];
                luaOnRenderObject = (LuaFunction)table["OnRenderObject"];
                luaOnWillRenderObject = (LuaFunction)table["OnWillRenderObject"];
                luaOnRenderImage = (LuaFunction)table["OnRenderImage"];
                luaOnDrawGizmosSelected = (LuaFunction)table["OnDrawGizmosSelected"];
                luaOnDrawGizmos = (LuaFunction)table["OnDrawGizmos"];
            }
        }

        LuaFunction luaOnPreCull;
        public void OnPreCull()
        {
            if (luaOnPreCull != null) luaOnPreCull.call(luaScripts);
        }

        LuaFunction luaOnPreRender;
        public void OnPreRender()
        {
            if (luaOnPreRender != null) luaOnPreRender.call(luaScripts);
        }

        LuaFunction luaOnPostRender;
        public void OnPostRender()
        {
            if (luaOnPostRender != null) luaOnPostRender.call(luaScripts);
        }

        LuaFunction luaOnRenderObject;
        public void OnRenderObject()
        {
            if (luaOnRenderObject != null) luaOnRenderObject.call(luaScripts);
        }

        LuaFunction luaOnWillRenderObject;
        public void OnWillRenderObject()
        {
            if (luaOnWillRenderObject != null) luaOnWillRenderObject.call(luaScripts);
        }

        LuaFunction luaOnRenderImage;
        public void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (luaOnRenderImage != null) luaOnRenderImage.call(luaScripts, source, destination);
        }

        LuaFunction luaOnDrawGizmosSelected;
        public void OnDrawGizmosSelected()
        {
            if (luaOnDrawGizmosSelected != null) luaOnDrawGizmosSelected.call(luaScripts);
        }

        LuaFunction luaOnDrawGizmos;
        public void OnDrawGizmos()
        {
            if (luaOnDrawGizmos != null) luaOnDrawGizmos.call(luaScripts);
        }
    }

    public class SluaTriggerBehaviour
     : SluaScriptsComponent
    {
        override public void setScripts(LuaTable table, string name)
        {
            if (table != null)
            {
                base.setScripts(table, name);
                luaOnTriggerEnter = (LuaFunction)table["OnTriggerEnter"];
                luaOnTriggerExit = (LuaFunction)table["OnTriggerExit"];
                luaOnTriggerStay = (LuaFunction)table["OnTriggerStay"];
                luaOnCollisionEnter = (LuaFunction)table["OnCollisionEnter"];
                luaOnCollisionExit = (LuaFunction)table["OnCollisionExit"];
                luaOnCollisionStay = (LuaFunction)table["OnCollisionStay"];
                luaOnControllerColliderHit = (LuaFunction)table["OnControllerColliderHit"];
                luaOnJointBreak = (LuaFunction)table["OnJointBreak"];
                luaOnParticleCollision = (LuaFunction)table["OnParticleCollision"];
            }
        }

        LuaFunction luaOnTriggerEnter;
        public void OnTriggerEnter(Collider other)
        {
            if (luaOnTriggerEnter != null) luaOnTriggerEnter.call(luaScripts, other);
        }

        LuaFunction luaOnTriggerExit;
        public void OnTriggerExit(Collider other)
        {
            if (luaOnTriggerExit != null) luaOnTriggerExit.call(luaScripts, other);
        }

        LuaFunction luaOnTriggerStay;
        public void OnTriggerStay(Collider other)
        {
            if (luaOnTriggerStay != null) luaOnTriggerStay.call(luaScripts, other);
        }

        LuaFunction luaOnCollisionEnter;
        public void OnCollisionEnter(Collision collision)
        {
            if (luaOnCollisionEnter != null) luaOnCollisionEnter.call(luaScripts, collision);
        }

        LuaFunction luaOnCollisionExit;
        public void OnCollisionExit(Collision collision)
        {
            if (luaOnCollisionExit != null) luaOnCollisionExit.call(luaScripts, collision);
        }

        LuaFunction luaOnCollisionStay;
        public void OnCollisionStay(Collision collision)
        {
            if (luaOnCollisionStay != null) luaOnCollisionStay.call(luaScripts, collision);
        }

        LuaFunction luaOnControllerColliderHit;
        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (luaOnControllerColliderHit != null) luaOnControllerColliderHit.call(luaScripts, hit);
        }

        LuaFunction luaOnJointBreak;
        public void OnJointBreak(float breakForce)
        {
            if (luaOnJointBreak != null) luaOnJointBreak.call(luaScripts, breakForce);
        }

        LuaFunction luaOnParticleCollision;
        public void OnParticleCollision(GameObject other)
        {
            if (luaOnParticleCollision != null) luaOnParticleCollision.call(luaScripts, other);
        }
    }
}

