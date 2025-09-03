
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

