import React from "react";

type InputProps = React.InputHTMLAttributes<HTMLInputElement> & {
    error?: boolean;
}

export const MyInput: React.FC<InputProps> = ({error, className="", ...props}) =>{
    return (
        <input 
            className={`border rounded-md px-3 py-2 focus:outline-none focus:ring-2 transition-colors
                ${error ? "border-red-500 focus:ring-red-400" : "border-gray-300 focus:ring-blue-400"}
                ${className}`}
            {...props}
        />
    );
}
