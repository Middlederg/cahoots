public class Styles
{
    public const string Link = "text-xs font-bold text-indigo-600 hover:text-indigo-800 lg:text-base";
    public const string Title = $"text-slate-700 font-semibold uppercase text-xl xl:text-4xl";
    public const string SubTitle = $"text-sm text-slate-600 tracking-widest lg:text-lg";
    public const string Container = $"h-full flex justify-center p-8";
    public const string PrimaryButton = "w-full bg-slate-700  hover:bg-slate-500 text-white " + Button;
    public const string SecondaryButton = "w-full bg-slate-200 hover:bg-slate-300 text-slate-700 " + Button;
    public const string PrimaryInlineButton = "bg-slate-700  hover:bg-slate-500 text-white " + Button;
    public const string SecondaryInlineButton = "bg-slate-200 hover:bg-slate-300 text-slate-700 " + Button;
    private const string Button = $"font-semibold outline-none focus:outline-none rounded-xl" +
        $"p-2 md:p-4 md:text-xl md:text-2xl uppercase outline-none focus:outline-none flex items-center justify-center";
    public const string Input = "font-semibold w-full block px-2 py-1.5 border border-slate-400 rounded-md text-sm shadow-sm focus:outline-none focus:border-slate-600";
    public const string ValidationError = "pt-1 color-red-500 text-xs font-semibold";
}
