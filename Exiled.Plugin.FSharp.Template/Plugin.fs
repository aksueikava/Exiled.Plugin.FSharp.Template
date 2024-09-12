namespace Exiled.Plugin.FSharp.Template

open Exiled.API.Enums
open Exiled.API.Features
open System

module private State =
    let mutable handlers: EventHandlers option = None

type Plugin() =
    inherit Plugin<Config>()

    static member val Instance: Plugin option = None with get, set

    override this.Name = "Exiled.Plugin.Template"
    override this.Prefix = "Exiled.Plugin.Template"
    override this.Author = "aksueikava"
    override this.Version = Version(1, 0, 0)
    override this.RequiredExiledVersion = Version(8, 11, 0)
    override this.Priority = PluginPriority.Default

    override this.OnEnabled() =
        Plugin.Instance <- Some this
        this.RegisterEvents()
        Log.Debug($"{this.Name} has been enabled.")
        base.OnEnabled()

    override this.OnDisabled() =
        Plugin.Instance <- None
        this.UnregisterEvents()
        Log.Debug($"{this.Name} has been disabled.")
        base.OnDisabled()

    member private this.RegisterEvents() =
        State.handlers <- Some (EventHandlers())

    member private this.UnregisterEvents() =
        State.handlers <- None