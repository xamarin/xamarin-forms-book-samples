namespace DisplayPlatformInfo

type public IPlatformInfo =
    abstract member GetModel : unit -> string
    abstract member GetVersion : unit -> string
