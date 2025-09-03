import React from "react";

type LabelProps = React.LabelHTMLAttributes<HTMLLabelElement> & {
  required?: boolean;
};

export const Label: React.FC<LabelProps> = ({ required, className = "", children, ...props }) => {
  return (
    <label className={`block font-medium mb-1 ${className}`} {...props}>
      {children} {required && <span className="text-red-500">*</span>}
    </label>
  );
};

type InputProps = React.InputHTMLAttributes<HTMLInputElement> & {
  error?: boolean;
};

export const Input: React.FC<InputProps> = ({ error, className = "", ...props }) => {
  return (
    <input
      className={`border rounded-md px-3 py-2 focus:outline-none focus:ring-2 transition-colors
        ${error ? "border-red-500 focus:ring-red-400" : "border-gray-300 focus:ring-blue-400"}
        ${className}`}
      {...props}
    />
  );
};

type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  variant?: "green" | "blue" | "gray";
  size?: "sm" | "md" | "lg";
};

const variantClasses = {
  green: "bg-green-500 hover:bg-green-600 text-white",
  blue: "bg-blue-500 hover:bg-blue-600 text-white",
  gray: "bg-gray-300 hover:bg-gray-400 text-gray-800",
};

const sizeClasses = {
  sm: "px-3 py-1 text-sm",
  md: "px-4 py-2 text-base",
  lg: "px-6 py-3 text-lg",
};

export const Button: React.FC<ButtonProps> = ({
  variant = "green",
  size = "md",
  className = "",
  ...props
}) => {
  return (
    <button
      className={`rounded-md font-medium transition-colors ${variantClasses[variant]} ${sizeClasses[size]} ${className}`}
      {...props}
    />
  );
};
