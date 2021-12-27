import Collapse from 'react-bootstrap/Collapse'
import React, { useEffect, useState } from 'react'
import Image from 'next/image'
import Hero from '../images/Home/Hero.svg'
function HomePage() {
  const [checked, setChecked] = useState(false)
  useEffect(() => {
    setChecked(true)
  }, [])
  return (
    <div className="p-3">
      <Image
        src={Hero}
        alt="home hero"
        width={1400}
        height={700}
        className="z-1"
      />
      <Collapse
        in={checked}
        {...(checked ? { timeout: 1000 } : {})}
        collapsedHeight={50}
      >
        Crypto <span className="text-blue-300">Chess</span>
      </Collapse>
    </div>
  )
}

export default HomePage
