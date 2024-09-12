namespace Exiled.Plugin.FSharp.Template

open Exiled.API.Interfaces
open System.ComponentModel

type Config() =
    interface IConfig with
        [<Description("Is the plugin enabled?")>]
        member val IsEnabled: bool = true with get, set

        [<Description("Are debug messages displayed?")>]
        member val Debug: bool = false with get, set