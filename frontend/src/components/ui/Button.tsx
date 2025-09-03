import React from 'react'

type ButtonProps = React.ButtonHTMLAttributes<HTMLButtonElement> & {
  vaiant: 'greean'|'blue'|'gray';
  size: 'sm'|'md'|'lg';
}

const variantClasses = {
  green
}